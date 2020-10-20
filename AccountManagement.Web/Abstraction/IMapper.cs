namespace AccountManagement.Web.Abstraction
{
    public interface IMapper<TSource, TDest>
    {
        TDest Map(TSource sourceData);

        TSource Map(TDest destData);
    }
}
