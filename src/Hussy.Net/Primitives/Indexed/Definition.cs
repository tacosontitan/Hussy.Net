/*
   Copyright 2024 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace Hussy.Net;

/// <summary>
/// Defines an indexed value for simplifying working with collections.
/// </summary>
/// <typeparam name="T">Specifies the type of the value being indexed.</typeparam>
public partial class Indexed<T>(
    int index,
    T value)
{
    /// <summary>
    /// Gets or sets the index of this element.
    /// </summary>
    public int I { get; set; } = index;

    /// <summary>
    /// Gets or sets the value of this indexed element.
    /// </summary>
    public T V { get; set; } = value;
}