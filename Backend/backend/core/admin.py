from django.contrib import admin
from .models import Device, BlockedSite

@admin.register(Device)
class DeviceAdmin(admin.ModelAdmin):
    list_display = ('device_id', 'locked')
    search_fields = ('device_id',)

@admin.register(BlockedSite)
class BlockedSiteAdmin(admin.ModelAdmin):
    list_display = ('domain',)