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

// Hussy.Net offers many functions for writing
// to the output stream, the simplest of which
// is W for "write line".
W("Hello, world!");

// If you need to write a separator, then
// the WS function can meet your needs
// with optional character and length
// parameters. The default character
// is '=' and the default length is
// 25.
WS(character: '_', length: 30);

// You can simply append to the stream
// using the A function:
A("Fizz");
A("Buzz");

// If you need to separate your output into
// visible chunks, then the WH method
// can facilitate writing a line preceded
// by two new lines.
WH("Sample Header");