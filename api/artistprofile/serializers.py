from django.contrib.auth.models import User, Group
from rest_framework import serializers
from artistprofile.models import ArtistProfile
from artisttrack.models import ArtistTrack

class SimpleArtistTrackSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = ArtistTrack
        fields = ('id', 'title', 'release_title', 'release_date',
                    'audio_file_url', 'image_file_url')
                    
                    
class ArtistProfileSerializer(serializers.HyperlinkedModelSerializer):
    tracks = SimpleArtistTrackSerializer(many=True, required=False)
    
    class Meta:
        model = ArtistProfile
        fields = ('id', 'name', 'hometown_city', 'hometown_state', 'biography',
                    'website_url', 'facebook_url', 'twitter_url', 'bandcamp_url', 'tracks')

    def create(self, validated_data):
        profile = ArtistProfile.objects.create(**validated_data)
        profile.owners.add(self.context.get("request").user)
        return profile