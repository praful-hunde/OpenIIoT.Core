﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                     ▄████████
      █     ███    ███                                                    ███    ███
      █     ███    █▀     ▄█████   ▄█████   ▄█████  █   ██████  ██▄▄▄▄    ███    █▀    ▄█████   ▄██████     ██     ██████     █████ ▄█   ▄
      █     ███          ██   █    ██  ▀    ██  ▀  ██  ██    ██ ██▀▀▀█▄  ▄███▄▄▄       ██   ██ ██    ██ ▀███████▄ ██    ██   ██  ██ ██   █▄
      █   ▀███████████  ▄██▄▄      ██       ██     ██▌ ██    ██ ██   ██ ▀▀███▀▀▀       ██   ██ ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ▀▀▀▀▀██
      █            ███ ▀▀██▀▀    ▀███████ ▀███████ ██  ██    ██ ██   ██   ███        ▀████████ ██    ▄      ██    ██    ██ ▀███████ ▄█   ██
      █      ▄█    ███   ██   █     ▄  ██    ▄  ██ ██  ██    ██ ██   ██   ███          ██   ██ ██    ██     ██    ██    ██   ██  ██ ██   ██
      █    ▄████████▀    ███████  ▄████▀   ▄████▀  █    ██████   █   █    ███          ██   █▀ ██████▀     ▄██▀    ██████    ██  ██  █████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Creates and extends Sessions.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.Core.Security
{
    using System;
    using System.Security.Claims;
    using NLog.xLogger;
    using OpenIIoT.SDK.Security;

    /// <summary>
    ///     Creates and extends <see cref="Session"/> s.
    /// </summary>
    public class SessionFactory
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        ///     Creates a new <see cref="Session"/> from the specified <see cref="User"/>.
        /// </summary>
        /// <param name="user">The User for which the Session is to be created.</param>
        /// <param name="sessionLength">The length of the Session, in seconds.</param>
        /// <returns>The created Session.</returns>
        public ISession CreateSession(IUser user, int sessionLength)
        {
            logger.EnterMethod(xLogger.Params(user, sessionLength));
            Session retVal;
            string userName = user?.Name ?? string.Empty;
            Role userRole = user?.Role ?? Role.Reader;

            ClaimsIdentity identity = new ClaimsIdentity("Token");
            identity.AddClaim(new Claim(ClaimTypes.Name, userName));

            for (int r = (int)userRole; r >= 0; r--)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, ((Role)r).ToString()));
            }

            string hash = SDK.Common.Utility.ComputeSHA512Hash(Guid.NewGuid().ToString());

            identity.AddClaim(new Claim(ClaimTypes.Hash, hash));

            retVal = new Session(user, identity, sessionLength);

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Extends the expiration time of the specified <see cref="Session"/> to the configured session length.
        /// </summary>
        /// <param name="session">The Session to extend.</param>
        /// <param name="sessionLength">The length of the Session, in seconds.</param>
        /// <returns>The extended Session.</returns>
        public ISession ExtendSession(ISession session, int sessionLength)
        {
            logger.EnterMethod(xLogger.Params(session, sessionLength));

            session.Expires = DateTime.UtcNow.AddSeconds(sessionLength);

            logger.ExitMethod(session);
            return session;
        }

        #endregion Public Methods
    }
}