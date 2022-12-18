namespace IM_server1.untils
{
    public class AppBeanFactory
    {

        private static IServiceProvider _Provider;

        public static T? getBean<T>()
        {
            return _Provider.GetService<T>();
        }
        public AppBeanFactory(IServiceProvider app)
        {
            _Provider = app;

        }
    }
}
