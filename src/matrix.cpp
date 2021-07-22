#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;


int main() {
    int W,H,R;
    cin>>H>>W>>R;
    int ncycles=min(W,H)/2;
    int m[W*H];
    int cycles[150][1196];
    int i,x,y;
    int cycle,cyclelen;
    for(i=0;i<W*H;i++)cin>>m[i];
    for(cycle=0;cycle<ncycles;cycle++){
        i=0;
        x=y=cycle;
        for(;y<H-cycle-1;y++)cycles[cycle][i++]=m[W*y+x];
        for(;x<W-cycle-1;x++)cycles[cycle][i++]=m[W*y+x];
        for(;y>cycle;y--)cycles[cycle][i++]=m[W*y+x];
        for(;x>cycle;x--)cycles[cycle][i++]=m[W*y+x];
    }
    for(cycle=0;cycle<ncycles;cycle++){
        cyclelen=2*(W-2*cycle)+2*(H-2*cycle)-4;
        i=-R%cyclelen+cyclelen;
        x=y=cycle;
        for(;y<H-cycle-1;y++)m[W*y+x]=cycles[cycle][i++%cyclelen];
        for(;x<W-cycle-1;x++)m[W*y+x]=cycles[cycle][i++%cyclelen];
        for(;y>cycle;y--)m[W*y+x]=cycles[cycle][i++%cyclelen];
        for(;x>cycle;x--)m[W*y+x]=cycles[cycle][i++%cyclelen];
    }
    for(y=0;y<H;y++){
        for(x=0;x<W;x++){
            if(x)cout<<' ';
            cout<<m[W*y+x];
        }
        cout<<endl;
    }
    return 0;
}