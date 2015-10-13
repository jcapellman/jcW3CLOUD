using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using Windows.Storage;

using jcW3CLOUD.PCL.Enums;
using jcW3CLOUD.PCL.Objects;
using jcW3CLOUD.PCL.PlatformAbstractions;

namespace jcW3CLOUD.UWP.PCL.PlatformImplementations {
    public class FileSystem : BaseFileSystem {
        public override async Task<CTO<T>> GetFile<T>(FILE_TYPES fileType) {
            var appFolder = ApplicationData.Current.LocalFolder;

            var filesinFolder = await appFolder.GetFilesAsync();

            var file = filesinFolder.FirstOrDefault(a => a.Name == fileType.ToString());

            if (file == null) {
                return new CTO<T>(default(T), $"{fileType} was not found");
            }

            var buffer = await FileIO.ReadBufferAsync(file);

            return new CTO<T>(GetObjectFromBytes<T>(buffer.ToArray()));
        }

        public override async Task<CTO<bool>> WriteFile<T>(FILE_TYPES fileType, T obj) {
            var storageFolder = ApplicationData.Current.LocalFolder;

            var objInBytes = GetBytesFromT(obj);

            using (var stream = await storageFolder.OpenStreamForWriteAsync(fileType.ToString(), CreationCollisionOption.ReplaceExisting)) {
                stream.Write(objInBytes, 0, objInBytes.Length);
            }

            return new CTO<bool>(true);
        }
    }
}