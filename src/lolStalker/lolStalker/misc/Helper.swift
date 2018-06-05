//
//  Helper.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/2/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

class Helper {
    struct Dimensions{
        let width:CGFloat
        let height:CGFloat
        
        init(width: CGFloat, height: CGFloat) {
            self.width = width
            self.height = height
        }
    }
    
    private static let reference: Dimensions = Dimensions(width: 375, height: 667)
    private static let original: Dimensions = Dimensions(width: UIScreen.main.bounds.width, height: UIScreen.main.bounds.height)
    
    static func getWidthOf(xdWidth: CGFloat, referenceWidth: CGFloat?, originalWidth: CGFloat?) -> CGFloat {
        var tempRefWidth: CGFloat
        var tempOrigWidth: CGFloat
        
        if let referenceWidth = referenceWidth {
            tempRefWidth = referenceWidth
        } else {
            tempRefWidth = reference.width
        }
        
        if let originalWidth = originalWidth {
            tempOrigWidth = originalWidth
        } else {
            tempOrigWidth = original.width
        }
        
        let percentage = ((xdWidth * 100) / tempRefWidth)
        return (percentage * tempOrigWidth) / 100
    }
    
    static func getHeightOf(xdHeight: CGFloat, referenceHeight: CGFloat?, originalHeight: CGFloat?) -> CGFloat {
        var tempRefHeight: CGFloat
        var tempOrigHeight: CGFloat
        
        if let referenceHeight = referenceHeight {
            tempRefHeight = referenceHeight
        } else {
            tempRefHeight = reference.height
        }
        
        if let originalHeight = originalHeight {
            tempOrigHeight = originalHeight
        } else {
            tempOrigHeight = original.height
        }
        
        let percentage = ((xdHeight * 100) / tempRefHeight)
        return (percentage * tempOrigHeight) / 100
    }
    
    static func getFontOf(xdFont: CGFloat, referenceHeight: CGFloat?, referenceWidth: CGFloat?) -> CGFloat {
        var tempRefHeight: CGFloat
        var tempRefWidth: CGFloat
        
        if let referenceHeight = referenceHeight {
            tempRefHeight = referenceHeight
        } else {
            tempRefHeight = reference.height
        }
        
        if let referenceWidth = referenceWidth {
            tempRefWidth = referenceWidth
        } else {
            tempRefWidth = reference.height
        }
        
//        return (((original.width / original.height) * xdFont) / (tempRefHeight / tempRefWidth))
        return ((xdFont * (original.width / original.height)) * 2)
    }
}
