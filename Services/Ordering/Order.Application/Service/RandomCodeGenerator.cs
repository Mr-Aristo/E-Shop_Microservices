namespace Order.Application.Service;

public static class RandomCodeGenerator
{
    /// <summary>
    /// Generates treace code
    /// </summary>
    /// <param name="lenght"></param>
    /// <returns></returns>
    public static string GenareRandomCode(int lenght)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new();
        StringBuilder result = new(lenght);

        for (int i = 0; i < lenght; i++)
        {
            result.Append(chars[random.Next(chars.Length)]);
        }

        return result.ToString();   
    }

}
