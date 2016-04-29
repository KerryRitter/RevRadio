from django.db import models
from django.conf import settings

class SavedRadioStation(models.Model):
    owner = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE, related_name="owner")
    
    search_query = models.CharField(max_length=100)

    created_at = models.DateTimeField(auto_now_add=True)
    
    def __str__(self):
        return self.created_by.userName + " - " + self.search_query