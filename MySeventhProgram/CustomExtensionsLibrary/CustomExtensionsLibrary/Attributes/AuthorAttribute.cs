namespace CustomExtensionsLibrary.Attributes
{
    /// <summary>
    /// Атрибут для указания информации об авторе класса или метода.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public sealed class AuthorAttribute : Attribute
    {
        /// <summary>
        /// Имя автора.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Электронная почта автора.
        /// </summary>
        public string? Email { get; set; }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AuthorAttribute"/>.
        /// </summary>
        /// <param name="name">Имя автора.</param>
        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }
}
