from artisttrack.models import ArtistTrack
from artisttrack.serializers import ArtistTrackSerializer
from rest_framework import viewsets
from artisttrack.permissions import IsAnArtistOwnerOrReadOnly

class ArtistTrackViewSet(viewsets.ModelViewSet):
    queryset = ArtistTrack.objects.all()
    serializer_class = ArtistTrackSerializer
    permission_classes = [IsAnArtistOwnerOrReadOnly]