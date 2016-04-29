from django.db import models
from django.conf import settings

class ArtistProfile(models.Model):
    owners = models.ManyToManyField(settings.AUTH_USER_MODEL)
    
    name = models.CharField(max_length=100)
    hometown_city = models.CharField(max_length=100)
    hometown_state = models.CharField(max_length=2)
    biography = models.CharField(max_length=1000)
    
    website_url = models.CharField(max_length=255)
    facebook_url = models.CharField(max_length=255)
    twitter_url = models.CharField(max_length=255)
    bandcamp_url = models.CharField(max_length=255)

    created_at = models.DateTimeField(auto_now_add=True)
    
    def __str__(self):
        return self.name