from django.db import models
from django.conf import settings
from artistprofile.models import ArtistProfile 

class ArtistTrack(models.Model):
    artist = models.ForeignKey(ArtistProfile, on_delete=models.CASCADE, related_name="tracks")
    created_by = models.ForeignKey(settings.AUTH_USER_MODEL)
    
    title = models.CharField(max_length=100)
    release_title = models.CharField(max_length=100)
    release_date = models.DateTimeField(auto_now_add=True)
    audio_file_url = models.CharField(max_length=255)
    image_file_url = models.CharField(max_length=255)

    created_at = models.DateTimeField(auto_now_add=True)
    
    def __str__(self):
        return self.artist.name + " - " + self.title 