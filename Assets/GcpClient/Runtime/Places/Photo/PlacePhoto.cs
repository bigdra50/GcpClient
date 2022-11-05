using System.Threading;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime.Places.Photo.Request;
using UnityEngine;

namespace GcpClient.Runtime.Places.Photo
{
    public class PlacePhoto
    {
        public int Height { get; }
        public int Width { get; }
        private readonly string _photoReference;
        private string[] _htmlAttributions;
        private Texture2D _photo;

        public PlacePhoto(int height, int width, string[] htmlAttributions, string photoReference)
        {
            _photoReference = photoReference;
            _htmlAttributions = htmlAttributions;
            Height = height;
            Width = width;
        }

        public async UniTask<Texture2D> LoadPhotoAsync(PhotoClient client, CancellationToken cancellationToken = default)
        {
            if (_photo != null) return _photo;
            if (Height == 0)
            {
                _photo = await client.RequestAsync(
                    new PhotoReference(_photoReference),
                    new MaxWidth(Width),
                    cancellationToken);
            }
            else if (Width == 0)
            {
                _photo = await client.RequestAsync(
                    new PhotoReference(_photoReference),
                    new MaxHeight(Height),
                    cancellationToken);
            }
            else
            {
                _photo = await client.RequestAsync(
                    new PhotoReference(_photoReference),
                    new MaxHeight(Height),
                    new MaxWidth(Width),
                    cancellationToken);
            }

            return _photo;
        }
    }
}