#include <stdio.h>

int main()
{
    for(int i = 0; i < 255; ++i)
    {
        printf("%5d%5c\n", i, i);
    }
    return 0;
} 