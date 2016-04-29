from userauth.serializers import UserSerializer
from django.contrib.auth.models import User
from rest_framework.response import Response
from rest_framework import permissions
from rest_framework.authtoken.models import Token
from rest_framework.views import APIView

class RegisterView(APIView):
    permission_classes = (permissions.AllowAny,)

    @staticmethod
    def post(request):
        serialized = UserSerializer(data=request.data, context=request)

        response_payload = {}

        if serialized.is_valid():
            user = User.objects.create_user(
                serialized.validated_data['username'].lower(),
                serialized.validated_data['email'].lower().strip(),
                request.data['password']
            )

            response_payload['success'] = True
            response_payload['token'] = Token.objects.get(user_id=user.id).key
        else:
            response_payload['success'] = False
            response_payload['errors'] = serialized._errors

        return Response(response_payload)


class LoginView(APIView):
    permission_classes = (permissions.AllowAny,)

    @staticmethod
    def post(request):
        serializer = UserSerializer(data=request.data, context=request)
        
        if serializer.is_valid() == False:
            response_payload  = {}
            response_payload['success'] = False
            response_payload['errors'] = serialized._errors
            return Response(response_payload)
            
        try:
            user = User.objects.get(username=serializer.validated_data['email'].lower().strip())
            is_valid = user.check_password(request.data['password'])
            if is_valid:
                return Response({
                    "success": True,
                    "token": Token.objects.get(user=user).key
                })
            else:
                raise Exception("Invalid password for email")
        except:
            return Response({
                "success": False,
                "errors": ["Invalid login. Please try again."]
            })