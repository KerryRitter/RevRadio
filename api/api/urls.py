from django.conf.urls import patterns, include, url
from artistprofile.views import ArtistProfileViewSet
from artisttrack.views import ArtistTrackViewSet
from userauth.views import RegisterView, LoginView
from radio.views import RadioViewSet
from rest_framework import routers
from rest_framework.authtoken import views as auth_token_views
from django.contrib import admin

router = routers.DefaultRouter()
router.register(r'api/artistprofile', ArtistProfileViewSet)
router.register(r'api/artisttrack', ArtistTrackViewSet)
router.register(r'api/radio', RadioViewSet)

urlpatterns = [
    url(r'^', include(router.urls)),
    url(r'^admin/', admin.site.urls),
    url(r'^api/auth/token/', include('rest_framework.urls', namespace='rest_framework')),
    url(r'^api/auth/register/', RegisterView.as_view()),
    url(r'^api/auth/login/', LoginView.as_view()),
]
