namespace Amazon.SecretsManager.Extensions.Caching
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for interacting with AWS Secrets Manager with added caching.
    /// </summary>
    public interface ISecretsManagerCache
    {
        /// <summary>
        /// Asynchronously retrieves the specified SecretString after calling <see cref="GetCachedSecret"/>.
        /// </summary>
        /// <param name="secretId">The secret id.</param>
        Task<string> GetSecretString(string secretId);

        /// <summary>
        /// Asynchronously retrieves the specified SecretBinary after calling <see cref="GetCachedSecret"/>.
        /// </summary>
        /// <param name="secretId">The secret id.</param>
        Task<byte[]> GetSecretBinary(string secretId);

        /// <summary>
        /// Requests the secret value from SecretsManager asynchronously and updates the cache entry with any changes.
        /// If there is no existing cache entry, a new one is created.
        /// Returns true or false depending on if the refresh is successful.
        /// </summary>
        /// <param name="secretId">The secret id.</param>
        Task<bool> RefreshNowAsync(string secretId);

        /// <summary>
        /// Returns the cache entry corresponding to the specified secret if it exists in the cache.
        /// Otherwise, the secret value is fetched from Secrets Manager and a new cache entry is created.
        /// </summary>
        /// <param name="secretId">The secret id.</param>
        SecretCacheItem GetCachedSecret(string secretId);
    }
}
