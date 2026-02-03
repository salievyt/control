from django.urls import path
from .views import get_policy
from .views import get_token

urlpatterns = [
    path("policy/<str:device_id>/", get_policy),
    path("api/token/", get_token),
]