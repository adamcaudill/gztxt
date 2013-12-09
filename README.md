##gztxt - A GZip Compressed Text File Format

####What is this?
A .gztxt file is a standard .txt that has been compressed with [gzip]() to make transport more efficient. This makes transferring and storing certain files (i.e. logs) easier.

What prompted this was the need to email error reports containing log files, without placing too much burden on email servers by storing large attachments.

####Use
gztxt consists of three parts:

* `gztxt` - A Windows application that handles the file association and opening the file in the default text editor.
* `gztxt-cli` - A command line utility to compress or decompress gztxt files.
* `libgztxt` - A library to allow applications to interact with gztxt files; both of the above applications are little more than wrappers for this library.

`gztxt.exe register` - Registers the `.gztxt` file type; this allows you to easily open files in your default text editor.

`gztxt.exe unregister` - Unregisters the file type.

`gztxt.exe <file>` - Decompresses the file to a temporary file and opens it in your default text editor.

For help with `gztxt-cli`, run `gztxt-cli.exe --help` to receive the most current information.

Documentation on the API exposed by `libgztxt` is coming soon.

####Compatibility

`.gztxt` files are standard `.gz` files, and can be extracted  or created with the `gzip` utility. There are no changes to the file format, the `gztxt` tools are intended to simplify a specific use-case for Windows users.

####Credits

Special thanks to those that have helped or provided resources:

* Icon: [Jojo Mendoza](http://www.deleket.com/) - CC Attribution-Noncommercial-No Derivate 3.0
* commandline: [gsscoder](https://github.com/gsscoder) - MIT


####License
This software is released under the MIT license.

See LICENSE.txt for more information.