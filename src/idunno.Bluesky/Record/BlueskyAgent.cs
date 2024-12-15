﻿// Copyright (c) Barry Dorrans. All rights reserved.
// Licensed under the MIT License.

using idunno.AtProto.Repo;
using idunno.AtProto;

using idunno.Bluesky.Record;

namespace idunno.Bluesky
{
    public partial class BlueskyAgent
    {
        /// <summary>
        /// Gets the post record for the specified <see cref="StrongReference"/>.
        /// </summary>
        /// <param name="strongReference">The <see cref="StrongReference" /> of the post to return the <see cref="PostRecord"/> for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="strongReference"/> is null.</exception>
        public async Task<AtProtoHttpResult<PostRecord>> GetPostRecord(
            StrongReference strongReference,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(strongReference);

            return await BlueskyServer.GetPost(
                strongReference,
                AuthenticatedOrUnauthenticatedServiceUri,
                AccessToken,
                HttpClient,
                loggerFactory: LoggerFactory,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a <see cref="ProfileRecord"/> for the current user.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="AuthenticatedSessionRequiredException">Thrown when the current session is not authenticated.</exception>
        public async Task<AtProtoHttpResult<ProfileRecord>> GetProfileRecord(
            CancellationToken cancellationToken = default)
        {
            if (!IsAuthenticated)
            {
                throw new AuthenticatedSessionRequiredException();
            }

            AtUri profileUri = new($"at://{Did}/{CollectionNsid.Profile}/self");

            return await GetRecord<ProfileRecord>(profileUri, service: Service, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the current user's <see cref="ProfileRecord"/>.
        /// </summary>
        /// <param name="profileRecord">The <see cref="ProfileRecord"/> to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="AuthenticatedSessionRequiredException">Thrown when the current session is not authenticated.</exception>
        public async Task<AtProtoHttpResult<PutRecordResponse>> UpdateProfileRecord(
            ProfileRecord profileRecord,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(profileRecord);
            ArgumentNullException.ThrowIfNull(profileRecord.Value);

            if (!IsAuthenticated)
            {
                throw new AuthenticatedSessionRequiredException();
            }

            if (profileRecord.Uri.Authority is not Did _)
            {
                throw new ArgumentException("Uri authority is not a DID", nameof(profileRecord));
            }

            if (profileRecord.Uri.Authority is Did recordDid && recordDid != Did)
            {
                throw new ArgumentException("Uri authority does not match the current user", nameof(profileRecord));
            }

            return await PutRecord(
                profileRecord.Value,
                collection: CollectionNsid.Profile,
                creator: Did,
                rKey: "self",
                validate: null,
                swapCommit: null,
                swapRecord: profileRecord.Cid,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

    }
}
