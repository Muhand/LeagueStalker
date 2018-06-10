//
//  UITableView.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/8/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

extension UITableView {
    func setEmptyMessage(_ message: String) {
        let messageLabel = UILabel(frame: CGRect(x: 0, y: 0, width: self.bounds.size.width, height: self.bounds.size.height))
        messageLabel.text = message
        messageLabel.textColor = UIColor(hex: "#95989A")
        messageLabel.numberOfLines = 0;
        messageLabel.textAlignment = .center;
        messageLabel.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 15, referenceHeight: nil, referenceWidth: nil))
        messageLabel.sizeToFit()
        
        self.backgroundView = messageLabel;
    }
    
    func restore() {
        backgroundView = nil
    }
}
