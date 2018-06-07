//
//  HomeViewController.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/6/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

class HomeViewController: UIViewController {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    
    ////////// END OF CONTROLS /////////
    override func viewDidLoad() {
        super.viewDidLoad()
        print("HOME")
        setupView()
        setupSubViews()
        setupConstraints()
        setupMargins()
    }
    
    func setupView() {
        view.backgroundColor = UIColor(hex: "#010A13")
        hideKeyboardWhenTappedAround()
    }
    
    func setupSubViews() {
        
    }
    
    func setupConstraints() {
        
    }
    
    func setupMargins() {
        
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)
        view.setNeedsDisplay()
    }
}
