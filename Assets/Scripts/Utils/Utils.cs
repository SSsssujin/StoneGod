public static class Utils 
{
    public static float ConvertAttackSpeedToInterval(int attackSpeed)
    {
        float interval = 0.5f;
        interval -= attackSpeed * 0.1f;
        return interval;
    }
    
    //public static string PlayerModelPath = "";
}
