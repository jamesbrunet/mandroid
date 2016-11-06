from django.shortcuts import render
from .models import HighScore
from django.utils import timezone
import json
# Create your views here.
from django.http import JsonResponse
from django.http import HttpResponse

def index(request):
    if request.POST:
        score = int(request.POST['score'])
        user_name = str(request.POST['user_name'])
        HighScore(score=score, username=user_name, score_date=timezone.now()).save()
        return HttpResponse("High Score Submitted")
    else:
        context = {}
        high_scores_list = []
        for high_score in HighScore.objects.order_by('-score')[:10]:
            high_scores_list.append({
                    'username': high_score.username,
                    'score': high_score.score,
                    'time': str(high_score.score_date.date()),
                }
            )
        context['high_scores'] = high_scores_list

        if "json" in request.GET.keys():
            return JsonResponse(context)
        else:
            return render(request, 'high_scores/index.html', context)