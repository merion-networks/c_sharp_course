namespace CustomExtensionsLibrary.Attributes
{
    /// <summary>
    /// Атрибут для указания версии класса или метода.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public sealed class VersionAttribute : Attribute
    {
        /// <summary>
        /// Версия.
        /// </summary>
        public string NumberVersion { get; }

        /// <summary>
        /// Описание изменений в версии.
        /// </summary>
        public string? Changes { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VersionAttribute"/>.
        /// </summary>
        /// <param name="number">Номер версии.</param>
        public VersionAttribute (string numberVersion)
        {
            NumberVersion = numberVersion;
        }

    }
}
