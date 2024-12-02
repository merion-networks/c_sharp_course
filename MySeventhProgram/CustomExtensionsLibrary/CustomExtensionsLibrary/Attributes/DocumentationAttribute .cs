namespace CustomExtensionsLibrary.Attributes
{

    /// <summary>
    /// Атрибут описания документации элемента
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DocumentationAttribute : Attribute
    {
        /// <summary>
        /// Свойство для хранения описания элемента
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Ссылка на соответствующую страницу в Confluence
        /// </summary>
        public string? ConfluenceLink { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DocumentationAttribute"/>.
        /// </summary>
        /// <param name="number">Описание дркументации.</param>
        public DocumentationAttribute(string description)
        {
            Description = description;
        }
    }
}
