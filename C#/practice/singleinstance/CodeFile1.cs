public sealed class Singleton
{
    //在Singleton第一次被调用时会执行instance的初始化
    private static readonly Singleton instance = new Singleton();

    private Singleton()
    {
    }

    public static Singleton Instance()
    {
        return instance;
    }
}
