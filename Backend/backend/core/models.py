from django.db import models

class Device(models.Model):
    device_id = models.CharField(max_length=64, unique=True)
    locked = models.BooleanField(default=False)

class BlockedSite(models.Model):
    domain = models.CharField(max_length=255)