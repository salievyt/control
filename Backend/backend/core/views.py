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