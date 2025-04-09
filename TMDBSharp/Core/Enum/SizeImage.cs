namespace TMDBSharp.Core.Enum;

public enum SizeImage
{
    W600H900,
    W533H300,
    W1920H1080,
    W1280H720,
}

internal class SizeImageUrlExtender
{
    public string GetUrl(SizeImage sizeImage)
    {
        return sizeImage switch
        {
            SizeImage.W533H300 => "w533_and_h300_bestv2",
            SizeImage.W600H900 => "w600_and_h900_bestv2",
            SizeImage.W1280H720 => "w1280_and_h720_bestv2",
            SizeImage.W1920H1080 => "w1920_and_h1080_bestv2",
            _ => "",
        };
    }
}