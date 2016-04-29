from artistprofile.models import ArtistProfile
from artistprofile.serializers import ArtistProfileSerializer
from rest_framework import viewsets
from artistprofile.permissions import IsAnOwnerOrReadOnly

class ArtistProfileViewSet(viewsets.ModelViewSet):
    queryset = ArtistProfile.objects.all()
    serializer_class = ArtistProfileSerializer
    permission_classes = [IsAnOwnerOrReadOnly]