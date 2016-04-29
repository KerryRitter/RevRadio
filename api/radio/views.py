from radio.models import SavedRadioStation
from radio.serializers import SavedRadioStationSerializer
from radio.permissions import IsOwner
from rest_framework import viewsets

class RadioViewSet(viewsets.ModelViewSet):
    queryset = SavedRadioStation.objects.all()
    serializer_class = SavedRadioStationSerializer
    permission_classes = [IsOwner]