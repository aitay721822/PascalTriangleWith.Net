# 使用Ｃ＃建立巴斯卡三角形
c#　巴斯卡三角形<br>
原理如下<br>
如果我今天要建立一個5階層的巴斯卡三角形<br>
那巴斯卡三角形會長成這樣<br>
<br>
<blockquote>
1 1 1 1 1<br>
1 2 3 4<br>
1 3 6<br>
1 4<br>
1<br>
</blockquote>
<br>
化成矩陣會長成這樣<br>
<br>
<blockquote>
[0,0] [0,1] [0,2] [0,3] [0,4]<br>
[1,0] [1,1] [1,2] [1,3]<br>
[2,0] [2,1] [2,2]<br>
[3,0] [3,1]<br>
[4,0]<br>
</blockquote>
<br>
規律是<br>
<blockquote>
C(m,0)=1 & C(0,n)=1<br>
C(m,n)=C(m-1,n)+C(m,n-1)<br>
</blockquote>
到這邊已經想到要怎麼做了嗎?<br>
<br>
首先建立一二維矩陣，假如是3階層<br>
那會長成這樣<br>
<blockquote>
[0,0] [0,1] [0,2]<br>
[1,0] [1,1] [1,2]<br>
[2,0] [2,1] [2,2]<br>
</blockquote>
那我們只要取出這樣就好<br>
<blockquote>
[0,0] [0,1] [0,2]<br>
[1,0] [1,1]<br>
[2,0]<br>
</blockquote>
那我們就可以開始找規律了<br>
<blockquote>
設n=3<br>
"i"從0開始到2結束共n層--(1)<br>
內圈"j"從0開始到n-i-1結束-(2)<br>
</blockquote>
這樣就可以取出我們想要的部分了<br>
＜巴斯卡三角形＞
