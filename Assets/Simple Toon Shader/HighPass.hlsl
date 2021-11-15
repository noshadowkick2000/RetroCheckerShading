
void HighPass_float(float Values, float Minimum, out float Output)
{
    if (Values < Minimum)
    {
        Output = 0;
    }
    else
    {
        Output = Values;
    }
}