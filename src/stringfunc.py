#!/bin/python3

import math
import os
import random
import re
import sys

class suffix:
    def __init__(self):
        self.index = 0
        self.rank = [0, 0]

# Complete the maxValue function below.
def buildSuffixArray(txt, n):
    suffixes = [suffix() for _ in range(n)]
    for i in range(n):
        suffixes[i].index = i
        suffixes[i].rank[0] = (ord(txt[i]) - ord("a"))
        suffixes[i].rank[1] = (ord(txt[i + 1]) - ord("a")) if ((i + 1) < n) else -1
    suffixes = sorted(suffixes, key = lambda x: (x.rank[0], x.rank[1]))
    ind = [0] * n  
    k = 4
    while (k < 2 * n):
        rank = 0
        prev_rank = suffixes[0].rank[0]
        suffixes[0].rank[0] = rank
        ind[suffixes[0].index] = 0
        for i in range(1, n):
            if (suffixes[i].rank[0] == prev_rank and
                suffixes[i].rank[1] == suffixes[i - 1].rank[1]):
                prev_rank = suffixes[i].rank[0]
                suffixes[i].rank[0] = rank     
            else:  
                prev_rank = suffixes[i].rank[0]
                rank += 1
                suffixes[i].rank[0] = rank
            ind[suffixes[i].index] = i
        for i in range(n):
            nextindex = suffixes[i].index + k // 2
            suffixes[i].rank[1] = suffixes[ind[nextindex]].rank[0] \
                if (nextindex < n) else -1
        suffixes = sorted(suffixes, key = lambda x: (x.rank[0], x.rank[1]))
        k *= 2
    suffixArr = [0] * n
    for i in range(n):
        suffixArr[i] = suffixes[i].index
    return suffixArr

def LCP(t, suffixArr):
    n = len(suffixArr)
    lcpArr = [0 for ctr in range(n)]
    invStuff = [0 for ctr in range(n)]
    for ctr in range(n):
        invStuff[suffixArr[ctr]] = ctr
    k = 0
    for ctr in range(n):
        if invStuff[ctr] == n - 1: 
            k = 0
            continue
        j = suffixArr[invStuff[ctr] + 1]
        while ctr + k < n and j + k < n and t[ctr + k] == t[j + k]: 
            k += 1
        lcpArr[invStuff[ctr]] = k
        if k > 0:
            k -= 1
    return lcpArr
       
def maxValue(t):
    sArr = buildSuffixArray(t, len(t))
    lcp = LCP(t, sArr)
    bestResults = len(t)
    for ctr in range(1, len(t)):
        cnt = 2
        for j in range(ctr - 1, -1, -1): 
            if lcp[j] >= lcp[ctr]:
                cnt += 1
            else: 
                break
        for j in range(ctr + 1, len(t)):
            if lcp[j] >= lcp[ctr]: 
                cnt += 1
            else: 
                break
        bestResults = max(bestResults, cnt * lcp[ctr])
    return bestResults

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')
    t = input()
    result = maxValue(t)
    fptr.write(str(result) + '\n')
    fptr.close()