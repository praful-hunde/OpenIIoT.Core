﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                              ▄████████
      █     ███    ███                                                              ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    █▀     █████    ▄█████   ▄█████      ██     ██████     █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███          ██  ██   ██   █    ██   ██ ▀███████▄ ██    ██   ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███         ▄██▄▄█▀  ▄██▄▄      ██   ██     ██  ▀ ██    ██  ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    █▄  ▀███████ ▀▀██▀▀    ▀████████     ██    ██    ██ ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███    ███   ██  ██   ██   █    ██   ██     ██    ██    ██   ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ ████████▀    ██  ██   ███████   ██   █▀    ▄██▀    ██████    ██  ██
      █
      █       ███
      █   ▀█████████▄
      █      ▀███▀▀██    ▄█████   ▄█████     ██      ▄█████
      █       ███   ▀   ██   █    ██  ▀  ▀███████▄   ██  ▀
      █       ███      ▄██▄▄      ██         ██  ▀   ██
      █       ███     ▀▀██▀▀    ▀███████     ██    ▀███████
      █       ███       ██   █     ▄  ██     ██       ▄  ██
      █      ▄████▀     ███████  ▄████▀     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Unit tests for the PackageCreator class.
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

using System;
using System.IO;
using Xunit;

namespace OpenIIoT.SDK.Packaging.Tests.Operations
{
    /// <summary>
    ///     Unit tests for the <see cref="Packaging.Operations.PackageCreator"/> class.
    /// </summary>
    public sealed class PackageCreator : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageCreator"/> class.
        /// </summary>
        public PackageCreator()
        {
            Creator = new Packaging.Operations.PackageCreator();

            Uri codeBaseUri = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string codeBasePath = Uri.UnescapeDataString(codeBaseUri.AbsolutePath);

            DataDirectory = Path.Combine(Path.GetDirectoryName(codeBasePath), "Data");
            PayloadDirectory = Path.Combine(DataDirectory, "Payload");

            TempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(TempDirectory);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the Package Creator to test.
        /// </summary>
        private Packaging.Operations.PackageCreator Creator { get; set; }

        /// <summary>
        ///     Gets or sets the data directory used for tests.
        /// </summary>
        private string DataDirectory { get; set; }

        /// <summary>
        ///     Gets or sets the payload directory used for tests.
        /// </summary>
        private string PayloadDirectory { get; set; }

        /// <summary>
        ///     Gets or sets the temporary directory used for tests.
        /// </summary>
        private string TempDirectory { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string)"/> method with a
        ///     blank directory.
        /// </summary>
        [Fact]
        public void CreatePackageBlankDirectory()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage(string.Empty, string.Empty, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string)"/> method with a
        ///     directory containing no files.
        /// </summary>
        [Fact]
        public void CreatePackageEmptyDirectory()
        {
            string directory = Path.Combine(TempDirectory, "empty");
            Directory.CreateDirectory(directory);

            Exception ex = Record.Exception(() => Creator.CreatePackage(directory, string.Empty, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string)"/> method with a
        ///     manifest containing no data.
        /// </summary>
        [Fact]
        public void CreatePackageEmptyManifest()
        {
            string manifest = Path.Combine(DataDirectory, "blankmanifest.json");
            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<InvalidDataException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string)"/> method with a
        ///     manifest containing invalid json data.
        /// </summary>
        [Fact]
        public void CreatePackageInvalidManifest()
        {
            string manifest = Path.Combine(DataDirectory, "invalidmanifest.json");
            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<FileLoadException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string)"/> method with a
        ///     directory which does not exist.
        /// </summary>
        [Fact]
        public void CreatePackageNotFoundDirectory()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage("not found", string.Empty, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<DirectoryNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string)"/> method with a
        ///     manifest which does not exist.
        /// </summary>
        [Fact]
        public void CreatePackageNotFoundManifest()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, "not found", string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string)"/> method with a
        ///     null directory.
        /// </summary>
        [Fact]
        public void CreatePackageNullDirectory()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage(null, string.Empty, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string)"/> method with a
        ///     null manifest argument.
        /// </summary>
        [Fact]
        public void CreatePackageNullManifest()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, null, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Disposes this instance of <see cref="PackageCreator"/>.
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(TempDirectory, true);
        }

        #endregion Public Methods
    }
}