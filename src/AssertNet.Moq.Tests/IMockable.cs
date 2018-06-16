namespace AssertNet.Moq.Tests
{
    /// <summary>
    /// Simple mockable interface.
    /// </summary>
    public interface IMockable
    {
        /// <summary>
        /// Gets or sets some number.
        /// </summary>
        /// <value>
        /// Some number.
        /// </value>
        int Number { get; set; }

        /// <summary>
        /// Gets some integer value.
        /// </summary>
        /// <returns>Some integer value.</returns>
        int GetInt();
    }
}
