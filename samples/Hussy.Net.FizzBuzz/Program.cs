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

// Hussy.Net has a built-in fizz buzz module
// that by default prints a specified number
// of values starting from 1:
W("Default");
Ws();
Fz(count: 20);

// You can specify a custom starting point:
Wh("Default (starting at 5)");
Ws();
Fz(start: 5, count: 20);

// For reference, you can also solve this problem with basic dialects:
Wh("Basic Dialects");
Ws();
Gr(start: 5, count: 20).E(i =>
{
    if (Dvb3(i))
        A("Fizz");

    if (Dvb5(i))
        A("Buzz");

    if (!i.Dvb(3, 5))
        A(i);

    W();
});