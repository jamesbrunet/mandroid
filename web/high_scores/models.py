from __future__ import unicode_literals

from django.db import models
# Create your models here.
class HighScore(models.Model):
    # Twitter length because we're internet 2.0
    username = models.CharField(max_length=140)
    score = models.IntegerField()
    score_date = models.DateTimeField("date score submitted")

    def __str__(self):
        return "{:<20}{:<14}{}\n".format(
            self.username,
            self.score,
            self.score_date.date())
