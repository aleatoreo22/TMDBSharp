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
        switch (sizeImage)
        {
            case SizeImage.W533H300:
                return "w533_and_h300_bestv2";
            case SizeImage.W600H900:
                return "w600_and_h900_bestv2";
            case SizeImage.W1280H720:
                return "w1280_and_h720_bestv2";
            case SizeImage.W1920H1080:
                return "w1920_and_h1080_bestv2";
        }
        return "";
    }
}