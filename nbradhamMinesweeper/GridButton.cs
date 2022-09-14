using System.Windows.Forms;

namespace nbradhamMinesweeper {
    
    /// <summary>
    /// Holds grid position with Button.
    /// </summary>
    internal class GridButton:Button {
        
        /// <summary>
        /// Grid X position.
        /// </summary>
        public byte GridX {
            get;
        }
        
        /// <summary>
        /// Grid Y position.
        /// </summary>
        public byte GridY {
            get;
        }
        
        /// <summary>
        /// Constructs new GridButton and sets position.
        /// </summary>
        /// <param name="setX">The grid X position.</param>
        /// <param name="setY">The grid Y position.</param>
        public GridButton(byte setX,byte setY) {
            GridX=setX;
            GridY=setY;
        }
    }
}