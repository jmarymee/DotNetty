namespace DotNetty.Handlers.Tls
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Net.Security;
    using System.Runtime.ExceptionServices;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using DotNetty.Buffers;
    using DotNetty.Codecs;
    using DotNetty.Common.Concurrency;
    using DotNetty.Common.Utilities;
    using DotNetty.Transport.Channels;

    /// <summary>
    /// Basically Decode, WriteAsync and Flush is all you need.
    //  if there's some sort of handshake in the beginning, you can override ChannelActive to initiate the handshake.
    //  you can override ChannelInactive to know when channel is shutting down.

    //  Important things to know:
    //- ByteToMessageDecoder is your friend.You can check how other implementations make use of it.
    //- writing out to network happens in two steps: WriteAsync is called -> Flush is called.
    //  WriteAsync may be called multiple times before Flush is called.That gives framework for optimizations - like batching data before encrypting or batch-posting it to network
    /// </summary>
    public sealed class TlsHandlerDCM : ByteToMessageDecoder
    {
        /// <summary>
        /// This method is used to decode data coming in from the network
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <param name="output"></param>
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            throw new NotImplementedException();
        }

        public static TlsHandlerDCM Server(X509Certificate certificate) => new TlsHandlerDCM();

        /// <summary>
        /// Read is an explicit request to read data from network (Max Gortman)
        /// You'd need to use that if you want explicit control when you read data from network.
        /// we do that to "throttle" in protocol gateway
        /// </summary>
        /// <param name="context"></param>
        public override void Read(IChannelHandlerContext context)
        {
            //TlsHandlerState oldState = this.state;
            //if (!oldState.HasAny(TlsHandlerState.AuthenticationCompleted))
            //{
            //    this.state = oldState | TlsHandlerState.ReadRequestedBeforeAuthenticated;
            //}

            //context.Read();
        }

        Task<int> ReadFromSslStreamAsync(IByteBuffer outputBuffer, int outputBufferLength)
        {
            //ArraySegment<byte> outlet = outputBuffer.GetIoBuffer(outputBuffer.WriterIndex, outputBufferLength);
            //return this.sslStream.ReadAsync(outlet.Array, outlet.Offset, outlet.Count);
            //Task<int> t = Task.Run(() =>
            //{
            //    return -1;
            //});
            //return t;

            return Task.Run(() => { return -1; });
        }

        public override Task WriteAsync(IChannelHandlerContext context, object message)
        {
            //if (!(message is IByteBuffer))
            //{
            //    return TaskEx.FromException(new UnsupportedMessageTypeException(message, typeof(IByteBuffer)));
            //}
            //return this.pendingUnencryptedWrites.Add(message);

            return Task.Run(() => { });
        }

        public override void Flush(IChannelHandlerContext context)
        {
            //if (this.pendingUnencryptedWrites.IsEmpty)
            //{
            //    this.pendingUnencryptedWrites.Add(Unpooled.Empty);
            //}

            //if (!this.EnsureAuthenticated())
            //{
            //    this.state |= TlsHandlerState.FlushedBeforeHandshake;
            //    return;
            //}

            //try
            //{
            //    this.Wrap(context);
            //}
            //finally
            //{
            //    // We may have written some parts of data before an exception was thrown so ensure we always flush.
            //    context.Flush();
            //}
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            base.ChannelActive(context);

            //if (!this.IsServer)
            //{
            //    this.EnsureAuthenticated();
            //}
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            // Make sure to release SslStream,
            // and notify the handshake future if the connection has been closed during handshake.
            //this.HandleFailure(ChannelClosedException);

            base.ChannelInactive(context);
        }

    }
}

