namespace RPM.Services.Data
{
    using System.Collections.Generic;

    public interface ISettingsService
    {
        int GetCount();

	void setCount();

        IEnumerable<T> GetAll<T>();
    }
}
