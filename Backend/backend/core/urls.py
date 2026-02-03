from django.urls import path
from .views import get_policy

urlpatterns = [
    path("policy/<str:device_id>/", get_policy),
]