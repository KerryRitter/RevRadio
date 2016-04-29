from django.contrib.auth.models import User, Group
from rest_framework import serializers
from artistprofile.models import ArtistProfile
from artisttrack.models import ArtistTrack
from artistprofile.serializers import ArtistProfileSerializer

class SimpleArtistProfileSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = ArtistProfile
        fields = ['id']

class ArtistTrackSerializer(serializers.HyperlinkedModelSerializer):
    artist = SimpleArtistProfileSerializer(required=False)
    
    class Meta:
        model = ArtistTrack
        fields = ['id', 'artist', 'title', 'release_title', 'release_date', 'audio_file_url', 'image_file_url']
                    
    def create(self, validated_data):
        request = self.context.get("request")
        artistId = request.data.get("artist").get("id")
        artist = request.user.artistprofile_set.get(id=artistId)
        if (artist):
            validated_data['artist'] = artist
            validated_data['created_by'] = request.user
            return ArtistTrack.objects.create(**validated_data)
        else:
            raise Exception("User is invalid")