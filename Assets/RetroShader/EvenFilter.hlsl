
void EvenFilter_float(float Values, float Step, out float Normal_channel, out float Dither_channel)
{
    if (Values/(1/Step)%2 != 0)
    {
        Dither_channel = Values;
        Normal_channel = 0;
    }
    else
    {
        Dither_channel = 0;
        Normal_channel = Values;
    }
}