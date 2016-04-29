from django.contrib import admin
from artistprofile.models import ArtistProfile
from artisttrack.models import ArtistTrack
from radio.models import SavedRadioStation

admin.site.register(ArtistProfile)
admin.site.register(ArtistTrack)
admin.site.register(SavedRadioStation)