/*
 * This file is part of ROMLaunch.
 *
 * ROMLaunch is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ROMLaunch is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ROMLaunch.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emu
{
    public class Emulator
    {
        public String emulatorPath;
        public String romFolderPath;
        public String[] fileExtensions;
        public String arguments;
        public String emulatorName;

        public Emulator(String emulatorPath, String romFolderPath, String[] fileExtensions, String emulatorName, String arguments)
        {
            this.emulatorPath = emulatorPath;
            this.romFolderPath = romFolderPath;
            this.fileExtensions = fileExtensions;
            this.emulatorName = emulatorName;
            this.arguments = arguments;
        }
    }
}
