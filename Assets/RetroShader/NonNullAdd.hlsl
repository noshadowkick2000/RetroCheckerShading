
void NonNullAdd_float(float Values, float Add, out float Output)
{
    if (Values == 0)
    {
        Output = 0;
    }
    else
    {
        Output = Values + Add;
    }
}