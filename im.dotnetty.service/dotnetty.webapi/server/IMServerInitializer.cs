using DotNetty.Codecs.Protobuf;
using DotNetty.Transport.Channels;
using Google.Protobuf.WellKnownTypes;
using dotnetty.webapi.handle;

namespace dotnetty.webapi.server
{
    public class IMServerInitializer : ChannelInitializer<IChannel>
    {
        IMServerHandle _handle;
        
        public IMServerInitializer(IMServerHandle handle)
        {
              _handle = handle;
        }
        protected override void InitChannel(IChannel channel)
        {
            var pipelin = channel.Pipeline;


            pipelin.AddLast(new ProtobufVarint32LengthFieldPrepender());
            pipelin.AddLast(new ProtobufEncoder());
            pipelin.AddLast(new ProtobufVarint32FrameDecoder());
            pipelin.AddLast(new ProtobufDecoder(IMRequest.Parser));

            pipelin.AddLast(this._handle);
        }
    }
}
