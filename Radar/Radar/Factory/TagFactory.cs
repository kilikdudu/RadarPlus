using Radar.BLL;


namespace Radar.Factory
{
    public static class TagFactory
    {
        private static TagBLL _Tag;

        public static TagBLL create() {
            if (_Tag == null)
                _Tag = new TagBLL();
            return _Tag;
        }
    }
}
