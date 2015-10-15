using System.Threading.Tasks;

using jcW3CLOUD.PCL.Enums;
using jcW3CLOUD.PCL.Objects;

namespace jcW3CLOUD.PCL.PlatformAbstractions {
    public abstract class BaseFileSystem : BasePA {
        public abstract Task<CTO<T>> GetFile<T>(FILE_TYPES fileType, bool encryptedFile = true);

        public abstract Task<CTO<bool>> WriteFile<T>(FILE_TYPES fileType, T obj, bool encryptFile = true);
    }
}