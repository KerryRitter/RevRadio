from django.contrib.auth.models import User, Group
from rest_framework import serializers
from radio.models import *

class SavedRadioStationSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = SavedRadioStation
        fields = ('id','search_query')

    def create(self, validated_data):
        validated_data['owner'] = self.context.get("request").user
        return SavedRadioStation.objects.create(**validated_data)