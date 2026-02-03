from django.http import JsonResponse
from .models import Device, BlockedSite

def get_policy(request, device_id):
    try:
        device = Device.objects.get(device_id=device_id)
    except Device.DoesNotExist:
        return JsonResponse({"error": "Device not found"}, status=404)

    sites = list(BlockedSite.objects.values_list("domain", flat=True))
    return JsonResponse({
        "lock": device.locked,
        "blocked_sites": sites
    })

# core/views.py
from rest_framework_simplejwt.tokens import RefreshToken
from django.contrib.auth.models import User
from rest_framework.decorators import api_view
from rest_framework.response import Response

@api_view(['POST'])
def get_token(request):
    username = request.data.get("username")
    password = request.data.get("password")
    user = User.objects.filter(username=username).first()
    if user and user.check_password(password):
        refresh = RefreshToken.for_user(user)
        return Response({"access": str(refresh.access_token)})
    return Response({"error": "Invalid credentials"}, status=401)